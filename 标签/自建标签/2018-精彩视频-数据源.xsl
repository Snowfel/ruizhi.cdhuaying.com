<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="nodeid" />
    <xsl:output method="html" />
    <xsl:template match="/">
        <NewDataSet>
            <xsl:for-each select="NewDataSet/Table">
                <Table>
                    <GeneralID>
                        <xsl:value-of select="GeneralID"/>
                    </GeneralID>
                    <ItemId>
                        <xsl:value-of select="ItemId"/>
                    </ItemId>
                    <Title>
                        <xsl:value-of select="pe:CutText(pe:RemoveHtml(Title),$titleLength,'…')" />
                    </Title>
                    <DefaultPicUrl>
                        &lt;img src="<xsl:value-of select="pe:UpLoadDir()"/>
                        <xsl:value-of select="DefaultPicUrl"/>" alt="<xsl:value-of select="Title"/>" border="0" /&gt;
                    </DefaultPicUrl>
                    <linkurl>
                        <xsl:value-of select="linkurl" />
                    </linkurl>
                    <Intro>
                        <xsl:value-of select="Intro" />
                    </Intro>
                    <InfoPath>
                        &lt;a data-url="<xsl:value-of select="linkurl" />" data-title="<xsl:value-of select="Title" />" data-target=".modal-video-show" data-toggle="modal" style="cursor: pointer;"
                           class="u-btn-show-video-modal d-block"&gt;&lt;/a&gt;
                    </InfoPath>
                </Table>
            </xsl:for-each>
        </NewDataSet>
    </xsl:template>
</xsl:stylesheet>